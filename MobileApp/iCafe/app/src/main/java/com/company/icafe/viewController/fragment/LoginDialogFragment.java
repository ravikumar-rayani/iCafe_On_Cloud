package com.company.icafe.viewController.fragment;

import android.content.res.Configuration;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.support.annotation.Nullable;
import android.support.design.widget.TextInputLayout;
import android.support.v4.app.DialogFragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.Toast;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;
import com.company.icafe.R;
import com.company.icafe.callback.LoginActionListener;
import com.company.icafe.model.Constants;

import java.util.HashMap;
import java.util.Map;

/**
 * Created by pmishra on 17/07/16.
 */

public class LoginDialogFragment extends DialogFragment implements View.OnClickListener{

    LoginActionListener loginActionListener;
    private EditText userNameEditText, passwordEditText;
    private LinearLayout parentLayout;

    public static LoginDialogFragment newInstance(LoginActionListener loginActionListener) {
        LoginDialogFragment loginDialogFragment = new LoginDialogFragment();
        loginDialogFragment.loginActionListener = loginActionListener;
        return loginDialogFragment;
    }

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {

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

        TextInputLayout serverIPAddressTextInputLayout = (TextInputLayout) view.findViewById(R.id.serverIPAddressTextInputLayout);
        serverIPAddressTextInputLayout.setVisibility(View.GONE);

        userNameEditText = (EditText) view.findViewById(R.id.serverUserNameEditbox);
        passwordEditText = (EditText) view.findViewById(R.id.serverPasswordEditbox);

        Button serverLoginButton = (Button) view.findViewById(R.id.serverConnectionButton);
        serverLoginButton.setText(getResources().getString(R.string.action_login));
        serverLoginButton.setOnClickListener(this);

        return view;
    }

    @Override
    public void onClick(View view) {
        switch (view.getId()){
            case R.id.serverConnectionButton:
                loginHttpRequest();
                if(userNameEditText.getText().toString().equals("1")) {
                    loginActionListener.loginActionCallback(Constants.WAITER_USER_MODE);
                }else if(userNameEditText.getText().toString().equals("11")) {
                    loginActionListener.loginActionCallback(Constants.TABLE_USER_MODE);
                }

                break;
        }
    }

    private void loginHttpRequest() {
        RequestQueue requestQueue = Volley.newRequestQueue(getActivity());

        StringRequest stringRequest = new StringRequest(Request.Method.POST, Constants.LOCAL_SERVER_URL + Constants.API_URL + Constants.USER_LOGIN,
                new Response.Listener<String>() {
                    @Override
                    public void onResponse(String response) {
                        Toast.makeText(getActivity(),"Login Successfull", Toast.LENGTH_LONG).show();
                        if(response.equalsIgnoreCase("5"))
                            loginActionListener.loginActionCallback(Constants.WAITER_USER_MODE);
                        else if(response.equalsIgnoreCase("6"))
                            loginActionListener.loginActionCallback(Constants.TABLE_USER_MODE);
                        getDialog().dismiss();
                    }
                },
                new Response.ErrorListener() {
                    @Override
                    public void onErrorResponse(VolleyError error) {
                        try {
                            Toast.makeText(getActivity(), error.toString(), Toast.LENGTH_LONG).show();
                            getDialog().dismiss();
                        }catch (Exception ex) {}
                    }
                }) {
            @Override
            protected Map<String,String> getParams(){
                Map<String,String> params = new HashMap<>();
                params.put("username", userNameEditText.getText().toString());
                params.put("password", passwordEditText.getText().toString());
                return params;
            }

        };

        requestQueue.add(stringRequest);
    }

    public void onConfigurationChanged(Configuration newConfig) {
        super.onConfigurationChanged(newConfig);

        if (newConfig.orientation == Configuration.ORIENTATION_LANDSCAPE) {
            parentLayout.setOrientation(LinearLayout.HORIZONTAL);
        } else if (newConfig.orientation == Configuration.ORIENTATION_PORTRAIT){
            parentLayout.setOrientation(LinearLayout.VERTICAL);
        }
    }

    Handler loginHandler = new Handler() {
        @Override
        public void handleMessage(Message msg) {
            super.handleMessage(msg);
        }
    };
}
