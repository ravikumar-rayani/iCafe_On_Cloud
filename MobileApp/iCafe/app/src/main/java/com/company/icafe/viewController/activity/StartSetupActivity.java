package com.company.icafe.viewController.activity;

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.support.v4.app.FragmentActivity;

import com.company.icafe.R;
import com.company.icafe.model.Constants;
import com.company.icafe.viewController.fragment.SetupServerConfigurationFragment;

/**
 * Created by pmishra on 12/07/16.
 */
public class StartSetupActivity extends FragmentActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        setContentView(R.layout.start_setup_layout);

        if(!initialDataLoaded()) {
            if (savedInstanceState == null) {
                getSupportFragmentManager()
                        .beginTransaction()
                        .replace(R.id.root_layout, SetupServerConfigurationFragment.newInstance(), "SetupServerConfigurationFragment")
                        .commit();
            }
        } else {
            Intent intent = new Intent(StartSetupActivity.this, AppHomeActivity.class);
            intent.putExtra(Constants.CURRENT_USER_MODE, Constants.DIGITAL_MENU_MODE);
            startActivity(intent);
            StartSetupActivity.this.finish();
        }


    }

    private boolean initialDataLoaded(){
        SharedPreferences sharedPreferences = this.getSharedPreferences(Constants.APP_SHARED_PREF, Context.MODE_PRIVATE);
        return sharedPreferences.getBoolean(Constants.SH_PREF_INITIAL_DATA_LOAD, false);
    }
}
