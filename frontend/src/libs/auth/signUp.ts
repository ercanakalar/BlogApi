import { createAsyncThunk } from '@reduxjs/toolkit';
import axios from 'axios';

export const signUp = createAsyncThunk(
  'auth/signUp',
  async (
    credentials: {
      email: string;
      userName: string;
      password: string;
      confirmPassword: string;
      role: string;
    },
    { rejectWithValue }
  ) => {
    try {
      const response = await axios.post(
        `${process.env.NEXT_PUBLIC_BACKEND_URL}/api/auth/signup`,
        credentials
      );
      const token = response.data.token;
      localStorage.setItem('authToken', token);
      return { user: response.data.data, token };
    } catch (error) {
      if (axios.isAxiosError(error) && error.response) {
        return rejectWithValue(error.response.data);
      } else {
        return rejectWithValue(error);
      }
    }
  }
);
