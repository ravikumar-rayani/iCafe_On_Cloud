package com.company.icafe.database;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.util.Log;

import com.company.icafe.callback.TableActionListener;
import com.company.icafe.model.Constants;
import com.company.icafe.model.Table;

import java.util.ArrayList;

/**
 * Created by pmishra on 11/10/16.
 */

public class TableDBHandler extends DBHandler implements TableActionListener{

    private final String LOG_TAG = TableDBHandler.class.getSimpleName();

    private static TableDBHandler tableDBHandler;

    public static TableDBHandler getInstance(Context context){
        if(tableDBHandler == null)
            tableDBHandler = new TableDBHandler(context);
        return tableDBHandler;
    }

    private TableDBHandler(Context context) {
        super(context);
    }

    @Override
    public void addTableItem(Table table) {
        SQLiteDatabase db = this.getWritableDatabase();
        addTableItemIntoDatabase(table, db);
        db.close();
    }

    @Override
    public void addTableItemList(ArrayList<Table> tableArrayList) {
        SQLiteDatabase db = this.getWritableDatabase();
        for (Table table: tableArrayList) {
            addTableItemIntoDatabase(table, db);
        }
        db.close();
    }

    @Override
    public ArrayList<Table> getAllTableItems() {
        SQLiteDatabase db = this.getReadableDatabase();
        ArrayList<Table> tableArrayList = new ArrayList<Table>();;
        try{
            Cursor cursor = db.rawQuery(DBQuery.constructSelectAllTableQuery(DBConstants.TABLE_ITEM_TABLE_NAME), null);
            if(!cursor.isLast())
            {
                while (cursor.moveToNext())
                {
                    Table tableItem = new Table();
                    tableItem.setId(cursor.getInt(cursor.getColumnIndex(DBConstants.TABLE_ITEM_ID)));
                    tableItem.setTableName(cursor.getString(cursor.getColumnIndex(DBConstants.TABLE_ITEM_NAME)));

                    tableArrayList.add(tableItem);
                }
            }
            db.close();
        }catch (Exception e){
            Log.e(Constants.APP_LOG_TAG,LOG_TAG+" getAllTableItems "  +e.getMessage());
        } finally {
            db.close();
        }
        return tableArrayList;
    }

    @Override
    public int getTableItemCount() {
        return 0;
    }

    private void addTableItemIntoDatabase(Table table, SQLiteDatabase sqLiteDatabase){
        try{
            ContentValues values = new ContentValues();
            values.put(DBConstants.TABLE_ITEM_ID, table.getId());
            values.put(DBConstants.TABLE_ITEM_NAME, table.getTableName());

            sqLiteDatabase.insert(DBConstants.TABLE_ITEM_TABLE_NAME, null, values);
        }catch (Exception e){
            Log.e(Constants.APP_LOG_TAG,LOG_TAG+" addTableItemIntoDatabase "  + e.getMessage());
        }
    }
}
