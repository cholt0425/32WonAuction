import { UserManager } from 'oidc-client';
import { storeUserError, storeUser } from '../store/actions/authActions'

const config = {
  authority: "https://localhost:5001",
  client_id: "auctionadmin",
  redirect_uri: "https://localhost:5001/signin-oidc",
  response_type: "id_token token",
  scope: "openid profile fullaccess",
  post_logout_redirect_uri: "https://localhost:5001/signout-oidc",
};

const userManager = new UserManager(config)

export async function loadUserFromStorage(dispatch) {
  try {
    let user = await userManager.getUser()
    if (!user) { return dispatch(storeUserError()) }
    dispatch(storeUser(user))
  } catch (e) {
    console.error(`User not found: ${e}`)
    dispatch(storeUserError())
  }
}

export function signinRedirect() {
  return userManager.signinRedirect()
}

export function signinRedirectCallback() {
  return userManager.signinRedirectCallback()
}

export function signoutRedirect() {
  userManager.clearStaleState()
  userManager.removeUser()
  return userManager.signoutRedirect()
}

export function signoutRedirectCallback() {
  userManager.clearStaleState()
  userManager.removeUser()
  return userManager.signoutRedirectCallback()
}

export default userManager