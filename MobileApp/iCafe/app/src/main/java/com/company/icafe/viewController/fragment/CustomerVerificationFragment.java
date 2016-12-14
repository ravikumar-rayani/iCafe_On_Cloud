package com.company.icafe.viewController.fragment;

import android.app.Dialog;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.app.DialogFragment;
import android.support.v4.app.FragmentManager;
import android.support.v7.widget.Toolbar;
import android.view.LayoutInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ProgressBar;
import android.widget.Toast;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;
import com.company.icafe.R;
import com.company.icafe.model.Constants;

/**
 * Created by pmishra on 12/11/16.
 */

public class CustomerVerificationFragment extends DialogFragment implements View.OnClickListener{

    public static final String TAG = CustomerVerificationFragment.class
            .getSimpleName();

    private Dialog CustomerVerificationFragmentDialog;
    private ProgressBar verificationProgressBar;
    private EditText customerMobileNo;
    private Button customerVerifyButton;

    public static CustomerVerificationFragment newInstance() {
        return new CustomerVerificationFragment();
    }

    public CustomerVerificationFragment() {
    }

    @Override
    public void onStart() {
        super.onStart();
        CustomerVerificationFragmentDialog = getDialog();
        if (CustomerVerificationFragmentDialog != null)
        {
            int width = ViewGroup.LayoutParams.MATCH_PARENT;
            int height = ViewGroup.LayoutParams.WRAP_CONTENT;
            CustomerVerificationFragmentDialog.getWindow().setLayout(width, height);
            CustomerVerificationFragmentDialog.setCancelable(false);
        }
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.customer_verification_dialog, container, false);

        customerMobileNo = (EditText) view.findViewById(R.id.customerMobileNoEditText);

        customerVerifyButton = (Button) view.findViewById(R.id.okButton);
        customerVerifyButton.setOnClickListener(this);

        verificationProgressBar = (ProgressBar) view.findViewById(R.id.verificationInProgressBar);

        // set the listener for Navigation
        Toolbar actionBar = (Toolbar) view.findViewById(R.id.customerVerificationLayoutToolBar);
        if (actionBar!=null) {
//            actionBar.inflateMenu(R.menu.action_bar_close);
            actionBar.setTitle("New Customer");
            actionBar.setOnMenuItemClickListener(new Toolbar.OnMenuItemClickListener() {
                @Override
                public boolean onMenuItemClick(MenuItem item) {
                    switch (item.getItemId()) {
                        case R.id.action_close_menu:
                            getDialog().dismiss();
                            break;
                        default:
                            break;
                    }
                    return true;
                }
            });
        }
        return view;
    }

    private void verifyCustomerRequest(String customerMobileNum){
        RequestQueue requestQueue = Volley.newRequestQueue(getActivity());

        String customerVerificationUrl = String.format(Constants.CUSTOMER_VERIFICATION, customerMobileNum);

        StringRequest stringRequest = new StringRequest(Request.Method.GET, Constants.LOCAL_SERVER_URL + Constants.API_URL + customerVerificationUrl,
                new Response.Listener<String>() {
                    @Override
                    public void onResponse(String response) {
                        Toast.makeText(getActivity(),response, Toast.LENGTH_LONG).show();

                        if(response.equalsIgnoreCase("true")){
                            customerVerifyButton.setEnabled(true);
                            CustomerVerificationFragmentDialog.dismiss();
                        } else if(response.equalsIgnoreCase("false")) {
                            FragmentManager fragmentManager = getActivity().getSupportFragmentManager();
                            CustomerDetailsFragment customerDetailsFragment = CustomerDetailsFragment.newInstance();
                            customerDetailsFragment.show(fragmentManager, "CustomerVerificationFragment");
                            CustomerVerificationFragmentDialog.dismiss();
                        }
                    }
                },
                new Response.ErrorListener() {
                    @Override
                    public void onErrorResponse(VolleyError error) {
                        verificationProgressBar.setVisibility(View.INVISIBLE);
                        customerVerifyButton.setEnabled(true);
                        Toast.makeText(getActivity(),error.toString(),Toast.LENGTH_LONG).show();
                    }
                });

        requestQueue.add(stringRequest);
    }

    @Override
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.okButton:
                String mobileNumber = customerMobileNo.getText().toString();

                if(mobileNumber != null && !mobileNumber.isEmpty()) {
                    verificationProgressBar.setVisibility(View.VISIBLE);
                    verifyCustomerRequest(customerMobileNo.getText().toString());
                } else {
                    Toast.makeText(getActivity(), "Please enter valid mobile number.", Toast.LENGTH_LONG).show();
                }
                break;
            default:
                break;
        }
    }
}
