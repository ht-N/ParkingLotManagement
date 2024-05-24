from datetime import datetime

def to_money(loaiphieu, loaixe, dt:datetime):
    days = dt.days
    seconds = dt.seconds

    hours, remainder = divmod(seconds, 3600)
    _, seconds = divmod(remainder, 60)
    result = days*24 + hours
    
    if(loaiphieu == 'Ngày'):
        if(loaixe == 'Xe máy'):
            result = (result/4)*3
        elif(loaixe == 'Ô tô'):
            result = (result/2)*15
    else:
        if(loaixe == 'Xe máy'):
            result = 150
        elif(loaixe == 'Ô tô'):
            result = 1250
        else:
            result = 100
    return str(int(result)) + ".000VND"
