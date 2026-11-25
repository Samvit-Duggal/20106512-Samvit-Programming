
import socket
import json
import psycopg2
import os
from dotenv import load_dotenv

load_dotenv()

HOST = "127.0.0.1"
PORT = 5000


# Connect to PostgreSQL
def db_connect():
    conn = psycopg2.connect(
        host=os.getenv("DB_HOST"),
        port=os.getenv("DB_PORT"),
        database=os.getenv("DB_NAME"),
        user=os.getenv("DB_USER"),
        password=os.getenv("DB_PASSWORD")
    )

    return conn


# Save member details in database
def save_member(data):
    conn = db_connect()

    try:
        cur = conn.cursor()

        query = """
        INSERT INTO members
        (full_name, address, contact_no, email, duration)
        VALUES (%s, %s, %s, %s, %s)
        RETURNING registration_no;
        """

        cur.execute(query, (
            data["name"],
            data["address"],
            data["contact"],
            data["email"],
            data["duration"]
        ))

        reg_no = cur.fetchone()[0]

        conn.commit()
        cur.close()

        return reg_no

    finally:
        conn.close()


# Start TCP server
def start_server():

    with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as server:

        server.bind((HOST, PORT))
        server.listen(5)

        print("================================")
        print("         LIBRARY SERVER")
        print("================================")
        print("Server started successfully.")
        print("Server IP:", HOST)
        print("Server Port:", PORT)

        while True:

            print("\nWaiting for client connection...")

            client, addr = server.accept()

            with client:
                print("Client connected:", addr)

                try:
                    # Receive complete JSON message
                    with client.makefile("r", encoding="utf-8") as msg:
                        data = json.loads(msg.readline())

                    print("Registration details received.")

                    if data["duration"] not in [6, 12]:
                        raise ValueError("Invalid membership duration.")

                    reg_no = save_member(data)

                    print("Member saved successfully.")
                    print("Registration Number:", reg_no)

                    response = {
                        "status": "success",
                        "registration_no": reg_no
                    }

                except Exception as e:
                    print("Error:", e)

                    response = {
                        "status": "error",
                        "message": "Registration failed."
                    }

                client.sendall(
                    (json.dumps(response) + "\n").encode("utf-8")
                )

                print("Response sent to client.")


# Run the server
if __name__ == "__main__":
    try:
        conn = db_connect()
        conn.close()

        print("Connected to PostgreSQL successfully!")

        start_server()

    except KeyboardInterrupt:
        print("\nServer stopped.")

    except Exception as e:
        print("Server error:", e)
