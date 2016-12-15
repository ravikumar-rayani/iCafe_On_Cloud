package com.company.icafe.viewController;

import android.app.Application;

import com.company.icafe.model.Constants;

/**
 * Created by pmishra on 15/12/16.
 */

public class ICafe extends Application {

    private static int currentViewMode = Constants.GRID_VIEW_MODE;
    private static int currentUserMode = Constants.DIGITAL_MENU_MODE;

    public static int getCurrentViewMode() {
        return currentViewMode;
    }

    public static void setCurrentViewMode(int currentViewMode) {
        ICafe.currentViewMode = currentViewMode;
    }

    public static int getCurrentUserMode() {
        return currentUserMode;
    }

    public static void setCurrentUserMode(int currentUserMode) {
        ICafe.currentUserMode = currentUserMode;
    }
}
