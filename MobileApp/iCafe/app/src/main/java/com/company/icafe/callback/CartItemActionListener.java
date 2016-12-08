package com.company.icafe.callback;

import com.company.icafe.model.CartItem;
import com.company.icafe.model.MenuItem;

import java.util.ArrayList;

/**
 * Created by pmishra on 22/08/16.
 */

public interface CartItemActionListener {
    public boolean insertOrUpdateMenuItemToCart(MenuItem menuItem);
    public ArrayList<CartItem> getCartItemList();
    public boolean updateMenuItemQuantityInCart(CartItem cartItem);
    public boolean removeMenuItemFromCart(CartItem cartItem);
    public CartItem getMenuItemFromCart(String cartItemId);
    public int getCartTotalPrice();
    public int getCartItemsCount();
}
