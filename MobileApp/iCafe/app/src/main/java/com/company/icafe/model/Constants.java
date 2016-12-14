package com.company.icafe.model;

/**
 * Created by pmishra on 06/08/16.
 */

public class Constants {

    public static final boolean DEMO_MODE = true;
    public static final String APP_LOG_TAG = "iCafe_Logs";
    public static final String APP_SHARED_PREF = "iCafe_Shared_Pref";

    public static final String SEARCH_INTENT_TAG = "search_text_tag";

    public static final String CURRENT_USER_MODE = "current_user_mode";
    public static final int ADMIN_MODE = 1111;
    public static final int DIGITAL_MENU_MODE = 2222;
    public static final int TABLE_USER_MODE = 3333;
    public static final int WAITER_USER_MODE = 4444;

    public static final int LIST_VIEW_MODE = 11;
    public static final int GRID_VIEW_MODE = 22;

    public static final String KEY_MENU_ITEMS = "MenuItems";

    public static final String SH_PREF_INITIAL_DATA_LOAD = "app_intial_data_load";

    public static final String LOCAL_SERVER_URL = "http://172.31.99.74"; //192.168.0.10";
    public static final String API_URL = "/icafe.service/api/mobile";

    public static final String GET_CATEGORY_URL = "/Menu/AllItemCategories";
    public static final String GET_MENU_ITEM_URL = "/Menu/AllItems";

    public static final String GET_WAITER_INFO = "/User/%s/WaiterInfo";

    public static final String USER_LOGIN = "/User/Login";
    public static final String CUSTOMER_VERIFICATION = "/Customer/%s/isExists";
}
