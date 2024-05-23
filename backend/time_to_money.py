from datetime import datetime

def to_money(loaiphieu, loaixe, dt:datetime):
    day = dt.day
    month = dt.month
    year = dt.year
    hour = dt.hour
    minute = 0 if dt.minute < 30 else 1
    second = dt.second

    result = day*24 + month*30*24 + year*365*24 + hour + minute
    return result
