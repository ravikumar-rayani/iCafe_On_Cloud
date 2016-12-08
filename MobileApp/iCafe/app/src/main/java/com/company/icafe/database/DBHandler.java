package com.company.icafe.database;

import android.content.Context;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

/**
 * Created by pmishra on 12/08/16.
 */

public class DBHandler extends SQLiteOpenHelper{

    private final String LOG_TAG = "DBHandler";

    private static DBHandler dbHandler;

    private static final String DB_NAME = "CityDatabase.db";
    private static final int DB_VERSION = 1;

    public static DBHandler getInstance(Context context){
        if(dbHandler == null)
            dbHandler = new DBHandler(context);
        return dbHandler;
    }

    public DBHandler(Context context) {
        super(context, DB_NAME, null, DB_VERSION);
    }

    @Override
    public void onCreate(SQLiteDatabase sqLiteDatabase) {
        sqLiteDatabase.execSQL(DBQuery.CREATE_MENU_ITEM_TABLE_QUERY);
        sqLiteDatabase.execSQL(DBQuery.CREATE_CART_TABLE_QUERY);

        sqLiteDatabase.execSQL(DBQuery.CREATE_ORDER_TABLE_QUERY);
        sqLiteDatabase.execSQL(DBQuery.CREATE_ORDER_DETAILS_TABLE_QUERY);
        sqLiteDatabase.execSQL(DBQuery.CREATE_SUBORDER_TABLE_QUERY);
        sqLiteDatabase.execSQL(DBQuery.CREATE_SUBORDER_ITEMS_TABLE_QUERY);

        sqLiteDatabase.execSQL(DBQuery.CREATE_CATEGORY_TABLE_QUERY);

        sqLiteDatabase.execSQL(DBQuery.CREATE_TABLE_ITEMS_TABLE_QUERY);
    }

    @Override
    public void onUpgrade(SQLiteDatabase sqLiteDatabase, int i, int i1) {
        sqLiteDatabase.execSQL(DBQuery.constructDropTableQuery(DBConstants.MENU_ITEM_TABLE_NAME));
        sqLiteDatabase.execSQL(DBQuery.constructDropTableQuery(DBConstants.CART_TABLE_NAME));

        sqLiteDatabase.execSQL(DBQuery.constructDropTableQuery(DBConstants.ORDER_TABLE_NAME));
        sqLiteDatabase.execSQL(DBQuery.constructDropTableQuery(DBConstants.ORDER_DETAILS_TABLE_NAME));
        sqLiteDatabase.execSQL(DBQuery.constructDropTableQuery(DBConstants.SUB_ORDER_TABLE_NAME));
        sqLiteDatabase.execSQL(DBQuery.constructDropTableQuery(DBConstants.SUB_ORDER_ITEM_TABLE_NAME));

        sqLiteDatabase.execSQL(DBQuery.constructDropTableQuery(DBConstants.CATEGORY_ITEM_TABLE));

        sqLiteDatabase.execSQL(DBQuery.constructDropTableQuery(DBConstants.TABLE_ITEM_TABLE_NAME));

        onCreate(sqLiteDatabase);
    }
}
