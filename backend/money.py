import sqlite3
import sys
from datetime import datetime
from time_to_money import to_money

def fetch_record(maphieu, thoi_gian_ra):
    # Define the path to your SQLite database
    db_path = r'..\\..\\AppData\\BAIXE.db'
    conn = sqlite3.connect(db_path)
    cursor = conn.cursor()
    try:
        query = f"SELECT * FROM PHIEU WHERE MAPHIEU = {maphieu};"
        cursor.execute(query)
        record = cursor.fetchone()
        format_dt = "%d-%m-%Y,%H:%M:%S"
        thoi_gian_vao = datetime.strptime(record[4], format_dt)
        thoi_gian_ra = datetime.strptime(thoi_gian_ra, format_dt)
        # print(thoi_gian_ra)
        time_park = thoi_gian_ra - thoi_gian_vao
        loaiphieu = record[1]
        loaixe = record[3]
        print(to_money(loaiphieu, loaixe, time_park))

    except sqlite3.Error as e:
        print("An error occurred:", e)
    
    finally:
        cursor.close()
        conn.close()


if __name__ == "__main__":
    if(len(sys.argv) != 3):
        print("Usage: python money.py <maphieu> <thoi_gian_ra>")
    else:
        maphieu = sys.argv[1]
        thoi_gian_ra = sys.argv[2]

        fetch_record(maphieu, thoi_gian_ra)