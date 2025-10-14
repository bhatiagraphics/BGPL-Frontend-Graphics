import pyodbc
import sys

server = 'bgserver1.database.windows.net'
database = 'GRAPHICPPC_NEW'
username = 'adminbg'
password = 'Bg@2025Azure'

print("=" * 80)
print("DEPLOYING SERVER-SIDE OPTIMIZATIONS")
print("=" * 80)
print()

if len(sys.argv) < 2:
    print("✗ Error: Please provide the path to the SQL script to execute.")
    sys.exit(1)

sql_file = sys.argv[1]

try:
    print("Connecting to Azure SQL Database...")
    conn = pyodbc.connect(
        f'DRIVER={{ODBC Driver 18 for SQL Server}};'
        f'SERVER={server};'
        f'DATABASE={database};'
        f'UID={username};'
        f'PWD={password}',
        timeout=120
    )
    print("✓ Connected successfully")
    print()

    print(f"Reading {sql_file}...")
    with open(sql_file, 'r') as f:
        sql_script = f.read()

    print(f"✓ Read {len(sql_script)} characters")
    print()

    batches = [b.strip() for b in sql_script.split('GO') if b.strip()]
    print(f"Executing {len(batches)} SQL batches...")
    print()

    cursor = conn.cursor()

    for i, batch in enumerate(batches, 1):
        print(f"Batch {i}/{len(batches)}...")
        cursor.execute(batch)
        conn.commit()
        print(f"✓ Batch {i} completed")

    print()
    print("✓ All batches executed successfully")
    print()

    cursor.close()
    conn.close()

    print("=" * 80)
    print("DEPLOYMENT COMPLETE")
    print("=" * 80)

except Exception as e:
    print(f"\n✗ Error: {e}")
    import traceback
    traceback.print_exc()
    sys.exit(1)