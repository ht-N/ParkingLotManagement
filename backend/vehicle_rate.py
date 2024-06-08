import os
import sqlite3

def get_rate():
    db_path = r'..\\..\\AppData\\BAIXE.db'
    conn = sqlite3.connect(db_path)
    cursor = conn.cursor()
    car = "Ô tô"
    motor = "Xe máy"
    bike = "Xe đạp"
    try:
        query = "SELECT COUNT(*) FROM PHIEU WHERE LOAIXE = ?;"
        cursor.execute(query, (car,))
        record = cursor.fetchone()
        car_num = int(record[0])
        cursor.execute(query, (motor,))
        record = cursor.fetchone()
        motor_num = int(record[0])
        cursor.execute(query, (bike,))
        record = cursor.fetchone()
        bike_num = int(record[0])
        print(car_num, motor_num, bike_num, sep="\n")

    except sqlite3.Error as e:
        print("An error occurred:", e)

    finally:
        cursor.close()
        conn.close()

if __name__ == "__main__":
    get_rate()
