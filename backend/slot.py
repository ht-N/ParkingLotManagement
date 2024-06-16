import sqlite3
import pandas as pd

db_path = r'..\\..\\AppData\\BAIXE.db'

def get_weekly_and_monthly_revenue(db_path):
    conn = sqlite3.connect(db_path)
    query = "SELECT * FROM DOANHTHU"
    df = pd.read_sql_query(query, conn)
    df['THOIGIAN'] = pd.to_datetime(df['THOIGIAN'], dayfirst=True)
    df.set_index('THOIGIAN', inplace=True)
    weekly_revenue = df['DOANHTHUNGAY'].resample('W').sum()
    monthly_revenue = df['DOANHTHUNGAY'].resample('M').sum()
    conn.close()
    return weekly_revenue, monthly_revenue

def main():
    weekly_revenue, monthly_revenue = get_weekly_and_monthly_revenue(db_path)
    print(weekly_revenue.iloc[-1], monthly_revenue.iloc[-1], sep="\n")

def get_slot():
    
    conn = sqlite3.connect(db_path)
    cursor = conn.cursor()
    car = "Ô tô"
    motor = 'Xe máy'
    try:
        query = "SELECT COUNT(*) FROM PHIEU WHERE LOAIXE = ?;"
        cursor.execute(query, (car,))
        record = cursor.fetchone()
        print(50 - record[0])
        cursor.execute(query, (motor,))
        record = cursor.fetchone()
        print(150 - record[0])

    except sqlite3.Error as e:
        print("An error occurred:", e)
    
    finally:
        cursor.close()
        conn.close()

if __name__ == "__main__":
    get_slot()
    main()