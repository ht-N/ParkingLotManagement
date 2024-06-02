import sqlite3

def get_slot():
    # Define the path to your SQLite database
    db_path = r'..\\..\\AppData\\BAIXE.db'
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