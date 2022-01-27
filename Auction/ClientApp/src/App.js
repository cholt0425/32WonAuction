import * as React from 'react';
import { Route, Switch } from 'react-router';
import { useDispatch } from 'react-redux';
import Home from './components/Home';
import userManager, { loadUserFromStorage } from './services/userService'
import Login from './components/login/login';
import SignoutOidc from './components/login/signout-oidc';
import SigninOidc from './components/login/signin-oidc';
import PrivateRoute from './utils/protectedRoute'

import './custom.css'


function App() {
    const dispatch = useDispatch();

    React.useEffect(() => {
        // fetch current user from cookies
        loadUserFromStorage(dispatch)
    }, [dispatch])

    return (
        <Switch>
            <Route path="/login" component={Login} />
            <Route path="/signout-oidc" component={SignoutOidc} />
            <Route path="/signin-oidc" component={SigninOidc} />
            <PrivateRoute exact path="/" component={Home} />
        </Switch>
    );
}

export default App;
