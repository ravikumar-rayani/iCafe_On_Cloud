package com.company.icafe.viewController.fragment;

import android.content.res.Configuration;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.LinearLayout;

import com.company.icafe.R;

/**
 * Created by pmishra on 12/07/16.
 */
public class SetupServerConfigurationFragment extends Fragment implements View.OnClickListener{

    private Button connectButton;
    public static final String TAG = SetupServerConfigurationFragment.class
            .getSimpleName();

    private LinearLayout parentLayout;

    public static SetupServerConfigurationFragment newInstance() {
        return new SetupServerConfigurationFragment();
    }

    public SetupServerConfigurationFragment() {
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.server_config_layout, container, false);

        parentLayout = (LinearLayout) view.findViewById(R.id.config_parent_layout);
        int currentOrientation = getResources().getConfiguration().orientation;
        if (currentOrientation == Configuration.ORIENTATION_LANDSCAPE) {
            // Landscape
            parentLayout.setOrientation(LinearLayout.HORIZONTAL);
        }
        else {
            // Portrait
            parentLayout.setOrientation(LinearLayout.VERTICAL);
        }

        connectButton = (Button) view.findViewById(R.id.serverConnectionButton);
        connectButton.setOnClickListener(this);
        return view;
    }

    @Override
    public void onClick(View view) {
        switch (view.getId()){
            case R.id.serverConnectionButton:

                getActivity().getSupportFragmentManager()
                        .beginTransaction()
                        .replace(R.id.root_layout, InitialDataLoadFragment.newInstance(), "InitialDataLoadFragment")
                        .commit();
                break;
        }
    }

    public void onConfigurationChanged(Configuration newConfig) {
        super.onConfigurationChanged(newConfig);

        if (newConfig.orientation == Configuration.ORIENTATION_LANDSCAPE) {
            parentLayout.setOrientation(LinearLayout.HORIZONTAL);
        } else if (newConfig.orientation == Configuration.ORIENTATION_PORTRAIT){
            parentLayout.setOrientation(LinearLayout.VERTICAL);
        }
    }
}
