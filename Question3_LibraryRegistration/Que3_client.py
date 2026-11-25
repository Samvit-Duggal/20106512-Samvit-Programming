
import socket
import json

HOST = "127.0.0.1"
PORT = 5000


# Collect user details
def get_details():

    print("================================")
    print("   ONLINE LIBRARY REGISTRATION")
    print("================================")

    name = input("Full Name: ")
    address = input("Residential Address: ")
    contact = input("Contact Number: ")
    email = input("Email Address: ")

    while True:
        duration = input("Membership Duration (6 or 12 months): ")

        if duration in ["6", "12"]:
            duration = int(duration)
            break
        else:
            print("Please enter 6 or 12 months.")

    data = {
        "name": name,
        "address": address,
        "contact": contact,
        "email": email,
        "duration": duration
    }

    return data


# Connect to server
def start_client():

    data = get_details()

    try:
        with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as client:

            print("\nConnecting to server...")

            client.connect((HOST, PORT))

            print("Connection established successfully!")

            # Send user details
            msg = json.dumps(data) + "\n"

            client.sendall(msg.encode("utf-8"))

            print("Registration details sent to server.")

            # Receive server response
            with client.makefile("r", encoding="utf-8") as msg:
                response = json.loads(msg.readline())

            if response["status"] == "success":

                print("\n================================")
                print("     REGISTRATION SUCCESSFUL")
                print("================================")

                print("Name:", data["name"])
                print("Registration Number:", response["registration_no"])
                print("Membership:", data["duration"], "months")

                print("\nThank you for registering!")

            else:
                print("Error:", response["message"])

    except ConnectionRefusedError:
        print("Unable to connect. Please start the server.")

    except Exception as e:
        print("Client error:", e)


# Run the client
if __name__ == "__main__":
    start_client()
