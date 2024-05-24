import sqlite3

def check_Entries():
    db_path = r'..\\..\\AppData\\BAIXE.db'
    conn = sqlite3.connect(db_path)
    cursor = conn.cursor()
    cursor.execute("SELECT MAPHIEU, LOAIXE FROM PHIEU")
    maphieu_loaixe_list = [(row[0], row[1]) for row in cursor.fetchall()]
    conn.close()
    return maphieu_loaixe_list

if __name__ == "__main__":
    maphieu_loaixe_list = check_Entries()
    for maphieu, loaixe in maphieu_loaixe_list:
        print(f"{maphieu},{loaixe}")