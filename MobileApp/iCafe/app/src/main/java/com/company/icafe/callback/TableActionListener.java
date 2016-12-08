package com.company.icafe.callback;

import com.company.icafe.model.Table;

import java.util.ArrayList;

/**
 * Created by pmishra on 11/10/16.
 */

public interface TableActionListener {
    public void addTableItem(Table table);

    public void addTableItemList(ArrayList<Table> tableArrayList);

    public ArrayList<Table> getAllTableItems();

    public int getTableItemCount();
}
