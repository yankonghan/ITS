using System;
using System.Collections;
using System.Data;

namespace PlayCardServer
{
	//Class to maintain the Userlist 
	public class ClientList 
	{
		private static ClientList mySingleton;
		private static DataTable clientTable;

		private ClientList()
		{
		}

		public static ClientList Instance()
		{
			if (mySingleton == null)
			{
				mySingleton = new ClientList();
				mySingleton.GenTable();
			}
			return mySingleton;
		}

		private void GenTable()
		{
			clientTable = new DataTable("UserList");
			DataColumn col;

			col = clientTable.Columns.Add("UserID", typeof(string));
			col.AllowDBNull = false;
			col = clientTable.Columns.Add("UserName", typeof(string));
			col.AllowDBNull = false;
			col = clientTable.Columns.Add("ImageIndex", typeof(int));
			col.AllowDBNull = false;
			col = clientTable.Columns.Add("IsOK", typeof(string));
			col.AllowDBNull = false;

			col = clientTable.Columns.Add("HallNumber", typeof(int));
			col.AllowDBNull = false;
			col = clientTable.Columns.Add("DeskNumber", typeof(int));
			col.AllowDBNull = false;
			col = clientTable.Columns.Add("DeskPosition", typeof(int));
			col.AllowDBNull = false;

			clientTable.PrimaryKey = new DataColumn[] {clientTable.Columns["UserID"]};
		}

		public DataRow FindUserRow(string UserID)
		{
			return clientTable.Rows.Find(UserID);
		}

		public void AddClient(string UserID, string UserName, int ImageIndex) 
		{ 
			lock(clientTable) 
			{ 
				if(! FindUser(UserID))
				{
					DataRow newRow = clientTable.NewRow();
					newRow["UserID"] = UserID;
					newRow["UserName"] = UserName;
					newRow["IsOK"] = "N";
					newRow["ImageIndex"] = ImageIndex;
					newRow["HallNumber"] = 0;
					newRow["DeskNumber"] = 0;
					newRow["DeskPosition"] = 0;

					clientTable.Rows.Add(newRow);
				}
			} 
		}

		public void RemoveClient(string UserID) 
		{ 
			lock(clientTable) 
			{ 
				DataRow row = clientTable.Rows.Find(UserID);
				if(row != null) 
				{ 
					clientTable.Rows.Remove(row); 
				}
			} 
		}

		public bool FindUser(string UserID)
		{
			DataRow row = clientTable.Rows.Find(UserID);
			if (row == null)		
				return false;
			else
				return true;
		}

        public DataTable GetUserList()
        {
            return clientTable;
        }
	}
}