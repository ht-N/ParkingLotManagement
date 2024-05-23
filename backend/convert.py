from datetime import datetime

# def convert_vndatetime(input_string):
#     input_string = input_string.replace("CH", "PM").replace("SA", "AM")
#     month_mapping = {
#         "Tháng Một": "January",
#         "Tháng Hai": "February",
#         "Tháng Ba": "March",
#         "Tháng Tư": "April",
#         "Tháng Năm": "May",
#         "Tháng Sáu": "June",
#         "Tháng Bảy": "July",
#         "Tháng Tám": "August",
#         "Tháng Chín": "September",
#         "Tháng Mười": "October",
#         "Tháng Mười Một": "November",
#         "Tháng Mười Hai": "December"
#     }
#     for vn_month, en_month in month_mapping.items():
#         if vn_month in input_string:
#             input_string = input_string.replace(vn_month, en_month)
#             break
#     input_format = "%I:%M:%S %p,%d %B %Y"
#     dt = datetime.strptime(input_string, input_format)
#     return dt

def convert_vndatetime(input_string):
    input_string = input_string.replace("CH", "PM").replace("SA", "AM")
    month_mapping = {
        "Tháng Một": "January",
        "Tháng Hai": "February",
        "Tháng Ba": "March",
        "Tháng Tư": "April",
        "Tháng Năm": "May",
        "Tháng Sáu": "June",
        "Tháng Bảy": "July",
        "Tháng Tám": "August",
        "Tháng Chín": "September",
        "Tháng Mười": "October",
        "Tháng Mười Một": "November",
        "Tháng Mười Hai": "December",
        "Tháng Một": "January",
        "Tháng Hai": "February",
        "Tháng Ba": "March",
        "Tháng Tư": "April",
        "Tháng Bảy": "July"
    }
    for vn_month, en_month in month_mapping.items():
        if vn_month in input_string:
            input_string = input_string.replace(vn_month, en_month)
            break
    input_format = "%I:%M:%S %p,%d %B %Y"
    dt = datetime.strptime(input_string, input_format)
    return dt


t1 = convert_vndatetime("11:55:34 PM,21 Tháng Năm 2024")
# t2 = convert_vndatetime("11:15:34 CH,20 Tháng Năm 2024")
print(t1)