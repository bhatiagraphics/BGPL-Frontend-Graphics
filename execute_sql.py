import pyodbc

server = 'bgserver1.database.windows.net'
database = 'GRAPHICPPC_NEW'
username = 'adminbg'
password = 'Bg@2025Azure'

try:
    conn = pyodbc.connect(
        f'DRIVER={{ODBC Driver 17 for SQL Server}};'
        f'SERVER={server};'
        f'DATABASE={database};'
        f'UID={username};'
        f'PWD={password}',
        timeout=120
    )

    with open('implement_pagination_jobentry_log.sql', 'r') as f:
        sql_script = f.read()

    batches = [b.strip() for b in sql_script.split('GO') if b.strip()]

    cursor = conn.cursor()

    for batch in batches:
        cursor.execute(batch)
        conn.commit()

    cursor.close()
    conn.close()

    print("SQL script executed successfully.")

except Exception as e:
    print(f"Error: {e}")