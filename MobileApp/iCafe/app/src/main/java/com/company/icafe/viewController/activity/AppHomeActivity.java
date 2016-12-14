package com.company.icafe.viewController.activity;

import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.support.design.widget.CoordinatorLayout;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.NavigationView;
import android.support.design.widget.Snackbar;
import android.support.design.widget.TabLayout;
import android.support.v4.app.DialogFragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.NavUtils;
import android.support.v4.view.GravityCompat;
import android.support.v4.view.ViewPager;
import android.support.v4.widget.DrawerLayout;
import android.support.v7.app.ActionBarDrawerToggle;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Toast;

import com.company.icafe.R;
import com.company.icafe.adapter.DigitalMenuViewPagerAdapter;
import com.company.icafe.adapter.ParseJsonData;
import com.company.icafe.adapter.WaiterViewPagerAdapter;
import com.company.icafe.callback.LoginActionListener;
import com.company.icafe.database.MenuDBHandler;
import com.company.icafe.database.OrderDBHandler;
import com.company.icafe.model.CategoryItem;
import com.company.icafe.model.Constants;
import com.company.icafe.ui.control.MaterialSearchView;
import com.company.icafe.viewController.fragment.CustomerVerificationFragment;
import com.company.icafe.viewController.fragment.LoginDialogFragment;
import com.company.icafe.viewController.fragment.WelcomeDialogFragment;

import java.util.ArrayList;
import java.util.LinkedHashMap;

public class AppHomeActivity extends AppCompatActivity
        implements NavigationView.OnNavigationItemSelectedListener, LoginActionListener {

    private final String TAG = AppHomeActivity.class.getSimpleName();

    boolean doubleBackToExitPressedOnce = false;
    private static FloatingActionButton actionFab, waiterProfileFab;
    private Toolbar toolbar;
    private TabLayout tabLayout;
    private ViewPager viewPager;
    private DigitalMenuViewPagerAdapter digitalMenuViewPagerAdapter;
    private WaiterViewPagerAdapter waiterViewPagerAdapter;

    private MaterialSearchView searchView;

    public static int currentViewMode = Constants.GRID_VIEW_MODE;

    public static int menuMode = Constants.DIGITAL_MENU_MODE;
    private final int loginActivityRequestCode = 1221;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_start_up);

        Intent intent = getIntent();
        menuMode = intent.getIntExtra(Constants.CURRENT_USER_MODE, Constants.DIGITAL_MENU_MODE);

        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        getSupportActionBar().setDisplayHomeAsUpEnabled(true);

        actionFab = (FloatingActionButton) findViewById(R.id.fab);
        actionFab.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Snackbar.make(view, "Replace with your own action", Snackbar.LENGTH_LONG)
                        .setAction("Action", null).show();
            }
        });

        DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawer_layout);
        ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(
                this, drawer, toolbar, R.string.navigation_drawer_open, R.string.navigation_drawer_close);
        drawer.setDrawerListener(toggle);
        toggle.syncState();

        NavigationView navigationView = (NavigationView) findViewById(R.id.nav_view);
        navigationView.setNavigationItemSelectedListener(this);

        viewPager = (ViewPager) findViewById(R.id.viewpager);
        viewPager.setFitsSystemWindows(true);

        tabLayout = (TabLayout) findViewById(R.id.tabs);

        viewPager.addOnPageChangeListener(new TabLayout.TabLayoutOnPageChangeListener(tabLayout));
        tabLayout.setOnTabSelectedListener(onTabSelectedListener(viewPager));

        loadDatabaseValues();

        initSearchView();

//        loadCustomerVerificationDialog();
    }

    @Override
    protected void onResume() {
        invalidateOptionsMenu();
        super.onResume();

        changeView(menuMode);
    }

    private TabLayout.OnTabSelectedListener onTabSelectedListener(final ViewPager pager) {
        return new TabLayout.OnTabSelectedListener() {
            @Override
            public void onTabSelected(TabLayout.Tab tab) {
                pager.setCurrentItem(tab.getPosition());
            }

            @Override
            public void onTabUnselected(TabLayout.Tab tab) {

            }

            @Override
            public void onTabReselected(TabLayout.Tab tab) {

            }
        };
    }

    @Override
    public void onBackPressed() {

        if (searchView.isSearchOpen()) {
            searchView.closeSearch();
        } else {
            DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawer_layout);
            if (drawer.isDrawerOpen(GravityCompat.START)) {
                drawer.closeDrawer(GravityCompat.START);
            } else {
                super.onBackPressed();
                return;
            }

            if (doubleBackToExitPressedOnce) {
                super.onBackPressed();
                return;
            }

            this.doubleBackToExitPressedOnce = true;
            Toast.makeText(this, "Please click BACK again to exit", Toast.LENGTH_SHORT).show();

            new Handler().postDelayed(new Runnable() {

                @Override
                public void run() {
                    doubleBackToExitPressedOnce = false;
                }
            }, 2000);
        }
    }

    @SuppressWarnings("StatementWithEmptyBody")
    @Override
    public boolean onNavigationItemSelected(MenuItem item) {

        switch (item.getItemId()){
            case R.id.nav_login:
                LoginDialogFragment loginDialogFragment = LoginDialogFragment.newInstance(this);
                loginDialogFragment.show(this.getSupportFragmentManager(), "loginDialog");
                break;
        }

        DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawer_layout);
        drawer.closeDrawer(GravityCompat.START);
        return true;
    }

    private void showWelcomePopup(){

        DialogFragment welcomeDialogFragment = new WelcomeDialogFragment();
        welcomeDialogFragment.show(getSupportFragmentManager(), "WelcomeDialog");
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        super.onCreateOptionsMenu(menu);
        getMenuInflater().inflate(R.menu.action_menu_search, menu);

        android.view.MenuItem item = menu.findItem(R.id.action_search_menu);
        searchView.setMenuItem(item);

        return true;
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);

        switch (requestCode) {
            case loginActivityRequestCode:
                switch (resultCode){
                    case RESULT_OK:
                    case RESULT_CANCELED:
                        Bundle bundle = data.getExtras();
                        menuMode = bundle.getInt(Constants.CURRENT_USER_MODE);
                        break;
                }
                break;
        }
    }

    public static int getCurrentMenuMode(){
        return menuMode;
    }

    private void loadDatabaseValues(){
        if(OrderDBHandler.getInstance(getApplicationContext()).getOrderCount() <= 0)
            OrderDBHandler.getInstance(getApplicationContext()).
                    addOrderList(ParseJsonData.newInstance(
                    getApplicationContext()).parseOrderItemData());
    }

    @Override
    public void loginActionCallback(int userMode) {
        menuMode = userMode;
        invalidateOptionsMenu();
        changeView(menuMode);
        viewPager.getAdapter().notifyDataSetChanged();
    }

    private void changeView(int mode){

        switch (mode) {
            case Constants.DIGITAL_MENU_MODE:
            case Constants.TABLE_USER_MODE:
                LinkedHashMap<CategoryItem, ArrayList<com.company.icafe.model.MenuItem>> categoryItemArrayListLinkedHashMap =
                        MenuDBHandler.getInstance(getApplicationContext()).getCategoryItemsWithMenuItems();

                digitalMenuViewPagerAdapter = new DigitalMenuViewPagerAdapter(getSupportFragmentManager(), categoryItemArrayListLinkedHashMap);
                viewPager.setAdapter(digitalMenuViewPagerAdapter);
                tabLayout.setupWithViewPager(viewPager);

//                fabVisibility(waiterProfileFab, false);
                actionFab.setImageDrawable(getResources().getDrawable(R.drawable.call_waiter, getApplicationContext().getTheme()));
                break;

            case Constants.WAITER_USER_MODE:

                waiterViewPagerAdapter = new WaiterViewPagerAdapter(getSupportFragmentManager());
                viewPager.setAdapter(waiterViewPagerAdapter);
                tabLayout.setupWithViewPager(viewPager);

//                fabVisibility(waiterProfileFab, true);
                actionFab.setImageDrawable(getResources().getDrawable(R.drawable.plus, getApplicationContext().getTheme()));
                break;
        }
    }

    private void fabVisibility(FloatingActionButton fabButton, boolean enable) {
        if(enable) {
            CoordinatorLayout.LayoutParams p1 = (CoordinatorLayout.LayoutParams) fabButton.getLayoutParams();
            p1.setBehavior(new FloatingActionButton.Behavior());
            p1.setAnchorId(R.id.tabs);
            fabButton.setLayoutParams(p1);
            fabButton.setVisibility(View.VISIBLE);
        } else {
            CoordinatorLayout.LayoutParams p = (CoordinatorLayout.LayoutParams) fabButton.getLayoutParams();
            p.setBehavior(null); //should disable default animations
            p.setAnchorId(View.NO_ID); //should let you set visibility
            fabButton.setLayoutParams(p);
            fabButton.setVisibility(View.GONE); // View.INVISIBLE might also be worth trying
        }
    }

    private void loadCustomerVerificationDialog() {
        FragmentManager fragmentManager = this.getSupportFragmentManager();
        CustomerVerificationFragment customerVerificationFragment = CustomerVerificationFragment.newInstance();
        customerVerificationFragment.show(fragmentManager, "CustomerVerificationFragment");

//        fragmentManager.beginTransaction()
//                .add(R.id.overlay_fragment_container, customerVerificationFragment)
//                .commit();
    }

    private void initSearchView() {
        searchView = (MaterialSearchView) findViewById(R.id.search_view);
        searchView.setVoiceSearch(false);
        searchView.setCursorDrawable(R.drawable.custom_cursor);
        searchView.setEllipsize(true);

        searchView.setOnQueryTextListener(new MaterialSearchView.OnQueryTextListener() {
            @Override
            public boolean onQueryTextSubmit(String query) {
                Intent searchIntent = new Intent(AppHomeActivity.this, SearchResultActivity.class);
                searchIntent.putExtra(Constants.SEARCH_INTENT_TAG, query);
                startActivity(searchIntent);
                return false;
            }

            @Override
            public boolean onQueryTextChange(String newText) {
                //Do some magic
                return false;
            }
        });

        searchView.setOnSearchViewListener(new MaterialSearchView.SearchViewListener() {
            @Override
            public void onSearchViewShown() {
                //Do some magic
                searchView.setSuggestions(getSearchSuggestionList());
            }

            @Override
            public void onSearchViewClosed() {
                //Do some magic
            }
        });
    }

    @Override
    public boolean onOptionsItemSelected(android.view.MenuItem item) {
        switch (item.getItemId()) {
            // Respond to the action bar's Up/Home button
            case android.R.id.home:
                NavUtils.navigateUpFromSameTask(this);
                return true;
        }
        return super.onOptionsItemSelected(item);
    }

    private String[] getSearchSuggestionList(){
        ArrayList<com.company.icafe.model.MenuItem> menuItems = MenuDBHandler.getInstance(this).getAllMenuItems();
        ArrayList<String> suggestions = new ArrayList<>();
        for (com.company.icafe.model.MenuItem menuItem:menuItems) {
            suggestions.add(menuItem.getName());
            String[] tagValues = menuItem.getTags();
            for (String tag:tagValues) {
                suggestions.add(tag);
            }
        }
        return suggestions.toArray(new String[suggestions.size()]);
    }
}
