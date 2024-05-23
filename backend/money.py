import sqlite3
import sys
from datetime import datetime
from convert import convert_vndatetime
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
        thoi_gian_vao = convert_vndatetime(record[4])
        thoi_gian_ra = convert_vndatetime(thoi_gian_ra)
        print(thoi_gian_ra)
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