package com.company.icafe.viewController.fragment;

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.company.icafe.R;
import com.company.icafe.callback.InitialDataLoadInterface;
import com.company.icafe.database.TableDBHandler;
import com.company.icafe.model.Constants;
import com.company.icafe.model.Table;
import com.company.icafe.tasks.GetServerResponseTask;
import com.company.icafe.viewController.activity.AppHomeActivity;

import java.util.ArrayList;

/**
 * Created by pmishra on 29/09/16.
 */

public class InitialDataLoadFragment  extends Fragment implements InitialDataLoadInterface {

    public static final String TAG = InitialDataLoadFragment.class
            .getSimpleName();

    public static InitialDataLoadFragment newInstance() {
        return new InitialDataLoadFragment();
    }

    public InitialDataLoadFragment() {
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.initial_data_load_layout, container, false);

        new GetServerResponseTask(getActivity().getApplicationContext(), this).execute();
        createTableList();
        return view;
    }

    @Override
    public void dataLoaded() {
        // Add initial data load as 'true' to shared preference
        SharedPreferences sharedPreferences = getActivity().getSharedPreferences(Constants.APP_SHARED_PREF, Context.MODE_PRIVATE);
        SharedPreferences.Editor sharedPrefEditor = sharedPreferences.edit();
        sharedPrefEditor.putBoolean(Constants.SH_PREF_INITIAL_DATA_LOAD, true);
        sharedPrefEditor.commit();

        // launch main screen of the application
        showHomeActivity();
    }

    private void showHomeActivity() {
        Intent intent = new Intent(getActivity(), AppHomeActivity.class);
        intent.putExtra(Constants.CURRENT_USER_MODE, Constants.DIGITAL_MENU_MODE);
        startActivity(intent);
        getActivity().finish();
    }

    private void createTableList(){
        ArrayList<Table> tableArrayList = new ArrayList<Table>();

        Table table = new Table();
        table.setId(1567);
        table.setTableName("Table 1");
        tableArrayList.add(table);

        table = new Table();
        table.setId(1568);
        table.setTableName("Table 2");
        tableArrayList.add(table);

        table = new Table();
        table.setId(1569);
        table.setTableName("Table 3");
        tableArrayList.add(table);

        table = new Table();
        table.setId(1570);
        table.setTableName("Table 4");
        tableArrayList.add(table);

        table = new Table();
        table.setId(1571);
        table.setTableName("Table 5");
        tableArrayList.add(table);

        table = new Table();
        table.setId(1572);
        table.setTableName("Table 6");
        tableArrayList.add(table);

        TableDBHandler.getInstance(getActivity().getApplicationContext()).addTableItemList(tableArrayList);
    }
}
