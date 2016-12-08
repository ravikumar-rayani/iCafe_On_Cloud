package com.company.icafe.database;

/**
 * Created by 20105480 on 26-08-2016.
 */
public class DBQuery {

    public static final String CREATE_MENU_ITEM_TABLE_QUERY = DBConstants.CREATE_TABLE + DBConstants.MENU_ITEM_TABLE_NAME
            + " ("
            + DBConstants.MENU_ITEM_ID + DBConstants.INTEGER_TYPE + DBConstants.COMMA_SEP
            + DBConstants.MENU_ITEM_NAME + DBConstants.TEXT_TYPE + DBConstants.COMMA_SEP
            + DBConstants.MENU_ITEM_CATEGORY_ID + DBConstants.TEXT_TYPE + DBConstants.COMMA_SEP
            + DBConstants.MENU_ITEM_IS_AVAILABLE + DBConstants.INTEGER_TYPE + DBConstants.COMMA_SEP
            + DBConstants.MENU_ITEM_PRICE + DBConstants.INTEGER_TYPE + DBConstants.COMMA_SEP
            + DBConstants.MENU_ITEM_SPICY_LEVEL + DBConstants.INTEGER_TYPE + DBConstants.COMMA_SEP
            + DBConstants.MENU_ITEM_INGREDIENTS + DBConstants.INTEGER_TYPE + DBConstants.COMMA_SEP
            + DBConstants.MENU_ITEM_DESCRIPTION + DBConstants.TEXT_TYPE + DBConstants.COMMA_SEP
            + DBConstants.MENU_ITEM_CREATED_DATE + DBConstants.DATE_TIME_TYPE + DBConstants.COMMA_SEP
            + DBConstants.MENU_ITEM_MODIFIED_DATE + DBConstants.DATE_TIME_TYPE + DBConstants.COMMA_SEP
            + DBConstants.MENU_ITEM_TAGS + DBConstants.TEXT_TYPE + DBConstants.COMMA_SEP
            + DBConstants.MENU_ITEM_THUMBNAIL_URL + DBConstants.TEXT_TYPE + DBConstants.COMMA_SEP
            + DBConstants.MENU_ITEM_IMAGE_URL + DBConstants.TEXT_TYPE
            +" )";

    public static final String CREATE_CATEGORY_TABLE_QUERY = DBConstants.CREATE_TABLE + DBConstants.CATEGORY_ITEM_TABLE
            + " ("
            + DBConstants.CATEGORY_ITEM_ID + DBConstants.INTEGER_TYPE + DBConstants.COMMA_SEP
            + DBConstants.CATEGORY_ITEM_NAME + DBConstants.TEXT_TYPE + DBConstants.COMMA_SEP
            + DBConstants.CATEGORY_ITEM_IS_AVAILABLE + DBConstants.INTEGER_TYPE + DBConstants.COMMA_SEP
            + DBConstants.CATEGORY_ITEM_DISCOUNT + DBConstants.INTEGER_TYPE + DBConstants.COMMA_SEP
            + DBConstants.CATEGORY_ITEM_IMAGE_URL + DBConstants.TEXT_TYPE + DBConstants.COMMA_SEP
            + DBConstants.CATEGORY_ITEM_DESCRIPTION + DBConstants.TEXT_TYPE
            +" )";

    public static final String CREATE_CART_TABLE_QUERY = DBConstants.CREATE_TABLE + DBConstants.CART_TABLE_NAME
            + " ("
            + DBConstants.MENU_ITEM_ID + DBConstants.INTEGER_TYPE + DBConstants.UNIQUE + DBConstants.COMMA_SEP
            + DBConstants.MENU_ITEM_NAME + DBConstants.INTEGER_TYPE + DBConstants.COMMA_SEP
            + DBConstants.MENU_ITEM_PRICE + DBConstants.INTEGER_TYPE + DBConstants.COMMA_SEP
            + DBConstants.MENU_ITEM_QUANTITY + DBConstants.INTEGER_TYPE + DBConstants.COMMA_SEP
            + DBConstants.MENU_ITEM_QUANTITY_PRICE + DBConstants.INTEGER_TYPE
            +" )";

    public static final String CREATE_ORDER_TABLE_QUERY = DBConstants.CREATE_TABLE + DBConstants.ORDER_TABLE_NAME
            + " ("
            + DBConstants.ORDER_ID + DBConstants.TEXT_TYPE+ DBConstants.COMMA_SEP
            + DBConstants.ORDER_PRICE + DBConstants.INTEGER_TYPE + DBConstants.COMMA_SEP
            + DBConstants.ORDER_PAYMENT_STATUS + DBConstants.INTEGER_TYPE + DBConstants.COMMA_SEP
            + DBConstants.ORDER_CREATED_DATE + DBConstants.DATE_TIME_TYPE + DBConstants.COMMA_SEP
            + DBConstants.ORDER_MODIFIED_DATE + DBConstants.DATE_TIME_TYPE
            +" )";

    public static final String CREATE_ORDER_DETAILS_TABLE_QUERY = DBConstants.CREATE_TABLE + DBConstants.ORDER_DETAILS_TABLE_NAME
            + " ("
            + DBConstants.ORDER_ID + DBConstants.TEXT_TYPE+ DBConstants.COMMA_SEP
            + DBConstants.SUB_ORDER_ID + DBConstants.TEXT_TYPE
            +" )";

    public static final String CREATE_SUBORDER_TABLE_QUERY = DBConstants.CREATE_TABLE + DBConstants.SUB_ORDER_TABLE_NAME
            + " ("
            + DBConstants.SUB_ORDER_ID + DBConstants.TEXT_TYPE+ DBConstants.COMMA_SEP
            + DBConstants.SUB_ORDER_PRICE + DBConstants.INTEGER_TYPE + DBConstants.COMMA_SEP
            + DBConstants.SUB_ORDER_STATUS + DBConstants.INTEGER_TYPE
            +" )";

    public static final String CREATE_SUBORDER_ITEMS_TABLE_QUERY = DBConstants.CREATE_TABLE + DBConstants.SUB_ORDER_ITEM_TABLE_NAME
            + " ("
            + DBConstants.SUB_ORDER_ID + DBConstants.TEXT_TYPE+ DBConstants.COMMA_SEP
            + DBConstants.SUB_ORDER_ITEM_ID + DBConstants.TEXT_TYPE + DBConstants.COMMA_SEP
            + DBConstants.SUB_ORDER_ITEM_NAME + DBConstants.TEXT_TYPE + DBConstants.COMMA_SEP
            + DBConstants.SUB_ORDER_ITEM_QUANTITY + DBConstants.TEXT_TYPE
            +" )";

    public static final String CREATE_TABLE_ITEMS_TABLE_QUERY = DBConstants.CREATE_TABLE + DBConstants.TABLE_ITEM_TABLE_NAME
            + " ("
            + DBConstants.TABLE_ITEM_ID + DBConstants.TEXT_TYPE+ DBConstants.COMMA_SEP
            + DBConstants.TABLE_ITEM_NAME + DBConstants.TEXT_TYPE
            +" )";

    public static String constructSelectAllTableQuery(String tableName) {
        return "SELECT * FROM " + tableName;
    }

    public static String constructDropTableQuery(String tableName) {
        return "DROP TABLE IF EXISTS " + tableName;
    }
}
