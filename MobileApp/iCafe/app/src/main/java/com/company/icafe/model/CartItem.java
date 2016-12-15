package com.company.icafe.model;

/**
 * Created by pmishra on 23/08/16.
 */

public class CartItem {

    private String menuItemId;

    private String menuItemName;

    private int menuItemQuantity;

    private int menuItemUnitPrice;

    private int menuItemQuantityPrice;

    public String getMenuItemId() {
        return menuItemId;
    }

    public void setMenuItemId(String menuItemId) {
        this.menuItemId = menuItemId;
    }

    public String getMenuItemName() {
        return menuItemName;
    }

    public void setMenuItemName(String menuItemName) {
        this.menuItemName = menuItemName;
    }

    public int getMenuItemQuantity() {
        return menuItemQuantity;
    }

    public void setMenuItemQuantity(int menuItemQuantity) {
        this.menuItemQuantity = menuItemQuantity;
    }

    public int getMenuItemUnitPrice() {
        return menuItemUnitPrice;
    }

    public void setMenuItemUnitPrice(int menuItemUnitPrice) {
        this.menuItemUnitPrice = menuItemUnitPrice;
    }

    public int getMenuItemQuantityPrice() {
        return menuItemQuantityPrice;
    }

    public void setMenuItemQuantityPrice(int menuItemQuantityPrice) {
        this.menuItemQuantityPrice = menuItemQuantityPrice;
    }
}
