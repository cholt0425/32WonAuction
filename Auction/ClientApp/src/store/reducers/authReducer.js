import { createSlice } from '@reduxjs/toolkit'

function clearUser(state) {
    state.isLoadingUser = false;
    state.user = null;
}

export const authSlice = createSlice({
    name: 'auth',
    initialState: {
        user: null,
        isLoadingUser: false
    },
    reducers: {
        storeUser: (state, action) => {
            // Redux Toolkit allows us to write "mutating" logic in reducers. It
            // doesn't actually mutate the state because it uses the Immer library,
            // which detects changes to a "draft state" and produces a brand new
            // immutable state based off those changes
            state.isLoadingUser = false;
            state.user = action.payload;
        },
        loadingUser: (state) => {
            state.isLoadingUser = true;
        },
        userExpired: (state) => {
            clearUser(state);
        },
        userError: (state) => {
            clearUser(state);
        },
        userSignedOut: (state) => {
            clearUser(state);
        },
        
    },
})

// Action creators are generated for each case reducer function
export const { storeUser, loadingUser, userExpired, userError, userSignedOut } = authSlice.actions

export default authSlice.reducer