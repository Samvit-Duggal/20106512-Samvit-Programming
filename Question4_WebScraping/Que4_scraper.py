
import requests
from bs4 import BeautifulSoup
import re
import json
import csv

# Wikipedia webpage URL
url = "https://en.wikipedia.org/wiki/List_of_Dublin_postal_districts"

headers = {
    "User-Agent": "DublinPostalDistrictsStudentProject/1.0"
}

# Fetch the webpage
res = requests.get(url, headers=headers, timeout=30)
res.raise_for_status()

soup = BeautifulSoup(res.text, "html.parser")

print("Webpage retrieved successfully!")

# Dictionary to store postal districts
districts = {}

headings = soup.find_all("h2")

# Extract district codes and area names
for h in headings:

    txt = h.get_text(strip=True)
    match = re.search(r"\((D\d+W?)\)", txt)

    if match:
        code = match.group(1)
        areas = []

        # Find the district description
        for tag in h.find_all_next(["h2", "p"]):

            if tag.name == "h2":
                break

            txt = tag.get_text(" ", strip=True)

            if txt.startswith("Dublin") and " includes " in txt:

                # Remove references
                txt = re.sub(r"\[.*?\]", "", txt)

                # Extract the first sentence
                txt = txt.split(". ")[0].rstrip(".")

                # Remove introductory text
                txt = txt.split(" includes ", 1)[1]

                # Clean special descriptions in D1 and D2
                if code == "D1" and "including " in txt:
                    txt = txt.split("including ", 1)[1]

                elif code == "D2" and "takes in areas around " in txt:
                    txt = txt.split("takes in areas around ", 1)[1]

                # Remove additional landmark information
                txt = txt.split(" and contains ")[0]

                # Remove text inside parentheses
                txt = re.sub(r"\([^)]*\)", "", txt)

                # Remove unnecessary phrases
                txt = re.sub(
                    r"\b(most of|parts of|areas such as)\s+",
                    "",
                    txt
                )

                # Separate individual area names
                names = re.split(r",|\s+and\s+", txt)

                for name in names:
                    name = name.strip()

                    if name and name not in areas:
                        areas.append(name)

                break

        districts[code] = areas

# Display extracted districts
for code, areas in districts.items():
    print(code, ":", areas)

print("\nTotal districts:", len(districts))

# Save data to JSON file
with open("dublin_postal_districts.json", "w",
          encoding="utf-8") as f:

    json.dump(districts, f, indent=4, ensure_ascii=False)

print("JSON file created successfully!")

# Read data from JSON file
with open("dublin_postal_districts.json", "r",
          encoding="utf-8") as f:

    data = json.load(f)

print("JSON file read successfully!")

# Convert JSON data to CSV file
with open("dublin_postal_districts.csv", "w",
          newline="", encoding="utf-8") as f:

    writer = csv.writer(f)

    # Write column headings
    writer.writerow(["Area Code", "Area Name"])

    # Write each area as a separate row
    for code, areas in data.items():

        for area in areas:

            writer.writerow([code, area])

print("CSV file created successfully!")

# Read and display data from CSV file
print("\n========================================")
print("       DUBLIN POSTAL DISTRICTS")
print("========================================")

with open("dublin_postal_districts.csv", "r",
          encoding="utf-8") as f:

    reader = csv.reader(f)

    for row in reader:

        print(f"{row[0]:<12} {row[1]}")

print("========================================")
print("All CSV records displayed successfully!")

# Display final summary
total = sum(len(areas) for areas in districts.values())

print("\nTotal postal districts:", len(districts))
print("Total area records:", total)
print("Program completed successfully!")
