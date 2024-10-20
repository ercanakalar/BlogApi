import { createSlice } from '@reduxjs/toolkit';

import { AuthState } from '@/types/authState';

const initialState: AuthState = {
  user: {
    username: '',
    email: '',
    id: '',
  },
  token: null,
  isAuthenticated: false,
  isLoading: false,
  error: null,
};

export const authSlice = createSlice({
  name: 'auth',
  initialState,
  reducers: {
    logout: (state) => {
      state.user = {
        username: '',
        email: '',
        id: '',
      };
      state.token = null;
      state.isAuthenticated = false;
      localStorage.removeItem('authToken');
    },
    setCredentials: (state, action) => {
      state.user = action.payload.user;
      state.token = action.payload.token;
      state.isAuthenticated = true;
    },
  },
});

export const { logout, setCredentials } = authSlice.actions;

export default authSlice.reducer;
