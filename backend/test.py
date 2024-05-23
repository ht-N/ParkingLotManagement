# import sqlite3
# import sys
# import datetime
# import os
# from convert import convert_vndatetime

# def fetch_record(maphieu, thoi_gian_ra):
#     # Define the path to your SQLite database
#     db_path = r'..\\..\\AppData\\BAIXE.db'  
#     print(f"THOIGIAN Ra: {thoi_gian_ra}")
    
#     conn = sqlite3.connect(db_path)
    
#     cursor = conn.cursor()
    
#     try:
#         # Query to fetch the record based on MAPHIEU
#         query = f"SELECT THOIGIAN FROM PHIEU WHERE MAPHIEU = ?;"
#         cursor.execute(query, [maphieu])
#         record = cursor.fetchone()

#         # Debugging: Print the fetched record
#         print(f"Fetched record: {record}")

#         # If no record is found, handle the case
#         if record is None:
#             print(f"No record found for MAPHIEU: {maphieu}")
#             return
        
#         # Convert the retrieved and passed datetime strings
#         thoi_gian_vao = convert_vndatetime(record[4])
#         thoi_gian_ra = convert_vndatetime(thoi_gian_ra)

#         # Print the results for debugging
#         print(f"THOIGIAN Vào: {thoi_gian_vao}")
#         print(f"THOIGIAN Ra: {thoi_gian_ra}")

#         # Additional processing logic can be added here

#     except sqlite3.Error as e:
#         print("An error occurred:", e)
    
#     finally:
#         cursor.close()
#         conn.close()

# if __name__ == "__main__":
#     if(len(sys.argv) != 3):
#         print("Usage: python money.py <maphieu> <thoi_gian_ra>")
#     else:
#         maphieu = sys.argv[1]
#         thoi_gian_ra = sys.argv[2]

#         fetch_record(maphieu, thoi_gian_ra)

import sqlite3
import sys
import os
from convert import convert_vndatetime

def fetch_record(maphieu, thoi_gian_ra):
    # Define the path to your SQLite database
    db_path = r'D:\LearningDocs\Nam2-HK2\NhapMonCNPM\ParkingLotManagement\frontend\AppData\BAIXE.db' 
    print(f"THOIGIAN Ra: {thoi_gian_ra}")
    
    try:
        conn = sqlite3.connect(db_path)
        cursor = conn.cursor()

        # Query to fetch the record based on MAPHIEU
        query = f"SELECT THOIGIAN FROM PHIEU WHERE MAPHIEU = {maphieu};"
        cursor.execute(query)
        record = cursor.fetchone()

        # Debugging: Print the fetched record
        print(f"Fetched record: {record}")

        # If no record is found, handle the case
        if record is None:
            print(f"No record found for MAPHIEU: {maphieu}")
            return
        
        # Convert the retrieved and passed datetime strings
        thoi_gian_vao = convert_vndatetime(record[0])
        thoi_gian_ra = convert_vndatetime(thoi_gian_ra)

        # Print the results for debugging
        print(f"THOIGIAN Vào: {thoi_gian_vao}")
        print(f"THOIGIAN Ra: {thoi_gian_ra}")

        # Additional processing logic can be added here

    except sqlite3.Error as e:
        print("An error occurred:", e)
    
    finally:
        cursor.close()
        conn.close()

if __name__ == "__main__":
    if len(sys.argv) != 3:
        print("Usage: python money.py <maphieu> <thoi_gian_ra>")
    else:
        maphieu = sys.argv[1]
        thoi_gian_ra = sys.argv[2]

        fetch_record(maphieu, thoi_gian_ra)
