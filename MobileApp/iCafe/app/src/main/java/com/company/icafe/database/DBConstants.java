package com.company.icafe.database;

/**
 * Created by pmishra on 21/08/16.
 */

public class DBConstants {

    // DB Syntax
    public static final String CREATE_TABLE = "CREATE TABLE ";
    public static final String PRIMARY_KEY = " PRIMARY KEY";
    public static final String UNIQUE = " UNIQUE";
    public static final String WHERE = " WHERE ";
    public static final String WHERE_EXPERSSION = " = ? ";

    // Data Type
    public static final String TEXT_TYPE = " TEXT";
    public static final String INTEGER_TYPE = " INTEGER";
    public static final String DATE_TIME_TYPE = " datetime";
    public static final String COMMA_SEP = ", ";

    // Menu
    public static final String MENU_ITEM_TABLE_NAME = "menu_item_table";
    public static final String MENU_ITEM_ID = "menu_item_id";
    public static final String MENU_ITEM_NAME = "menu_item_name";
    public static final String MENU_ITEM_CATEGORY_ID = "menu_item_CategoryId";
    public static final String MENU_ITEM_IS_AVAILABLE = "menu_item_isAvailable";
    public static final String MENU_ITEM_PRICE = "menu_item_price";
    public static final String MENU_ITEM_SPICY_LEVEL = "menu_item_spicyLevel";
    public static final String MENU_ITEM_INGREDIENTS = "menu_item_ingredients";
    public static final String MENU_ITEM_DESCRIPTION = "menu_item_description";
    public static final String MENU_ITEM_CREATED_DATE = "menu_item_createdOn";
    public static final String MENU_ITEM_MODIFIED_DATE = "menu_item_modifiedOn";
    public static final String MENU_ITEM_TAGS = "menu_item_tags";
    public static final String MENU_ITEM_THUMBNAIL_URL = "menu_item_thumbnail_url";
    public static final String MENU_ITEM_IMAGE_URL = "menu_item_image_url";

    // Cart
    public static final String CART_TABLE_NAME = "cart_table";
    public static final String MENU_ITEM_QUANTITY = "menu_item_quantity";
    public static final String MENU_ITEM_QUANTITY_PRICE = "menu_item_quantity_price";

    // Order
    public static final String ORDER_TABLE_NAME = "order_table";
    public static final String ORDER_ID = "order_id";
    public static final String ORDER_PRICE = "order_price";
    public static final String ORDER_PAYMENT_STATUS = "order_payment_status";
    public static final String ORDER_CREATED_DATE = "order_created_date";
    public static final String ORDER_MODIFIED_DATE = "order_modified_date";

    public static final String ORDER_DETAILS_TABLE_NAME = "order_details_table";

    // SubOrder
    public static final String SUB_ORDER_TABLE_NAME = "sub_order_table";
    public static final String SUB_ORDER_ID = "sub_order_id";
    public static final String SUB_ORDER_PRICE = "sub_order_price";
    public static final String SUB_ORDER_STATUS = "sub_order_status";

//    public static final String SUB_ORDER_DETAILS_TABLE_NAME = "sub_order_details_table";

    // SubOrderItem
    public static final String SUB_ORDER_ITEM_TABLE_NAME = "sub_order_item_table";
    public static final String SUB_ORDER_ITEM_ID = "sub_order_item_id";
    public static final String SUB_ORDER_ITEM_NAME = "sub_order_item_name";
    public static final String SUB_ORDER_ITEM_QUANTITY = "sub_order_item_quantity";

    // CategoryItem
    public static final String CATEGORY_ITEM_TABLE = "category_item_table";
    public static final String CATEGORY_ITEM_ID = "category_item_id";
    public static final String CATEGORY_ITEM_NAME = "category_item_name";
    public static final String CATEGORY_ITEM_IS_AVAILABLE = "category_item_is_available";
    public static final String CATEGORY_ITEM_DISCOUNT = "category_item_discount";
    public static final String CATEGORY_ITEM_IMAGE_URL = "category_item_image_url";
    public static final String CATEGORY_ITEM_DESCRIPTION = "category_item_description";

    // Table
    public static final String TABLE_ITEM_TABLE_NAME = "table_item_table";
    public static final String TABLE_ITEM_ID = "table_item_id";
    public static final String TABLE_ITEM_NAME = "table_item_name";
}
