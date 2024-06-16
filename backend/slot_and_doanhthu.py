import sqlite3
import pandas as pd
import sys

db_path = r'..\\..\\AppData\\BAIXE.db'

def get_slot_and_doanh_thu():
    conn = sqlite3.connect(db_path)
    cursor = conn.cursor()
    car = "Ô tô"
    motor = 'Xe máy'
    try:
        query = "SELECT COUNT(*) FROM PHIEU WHERE LOAIXE = ?;"
        cursor.execute(query, (car,))
        record = cursor.fetchone()
        sys.stdout.write(f"{50 - record[0]}\n")
        cursor.execute(query, (motor,))
        record = cursor.fetchone()
        sys.stdout.write(f"{150 - record[0]}\n")
        query = "SELECT * FROM DOANHTHU"
        df = pd.read_sql_query(query, conn)
        df['THOIGIAN'] = pd.to_datetime(df['THOIGIAN'], dayfirst=True)
        df.set_index('THOIGIAN', inplace=True)
        weekly_revenue = df['DOANHTHUNGAY'].resample('W').sum()
        monthly_revenue = df['DOANHTHUNGAY'].resample('M').sum()
        sys.stdout.write(f"{weekly_revenue.iloc[-1]}\n{monthly_revenue.iloc[-1]}")

    except sqlite3.Error as e:
        print("An error occurred:", e)
    
    finally:
        cursor.close()
        conn.close()

if __name__ == "__main__":
    get_slot_and_doanh_thu()