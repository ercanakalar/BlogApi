import { createAsyncThunk } from '@reduxjs/toolkit';
import axios from 'axios';

export const createBlog = createAsyncThunk(
  'comment/createBlog',
  async (
    credentials: { content: string; title: string },
    { rejectWithValue }
  ) => {
    try {
      const token = localStorage.getItem('authToken');

      if (!token) {
        throw new Error('No token found');
      }

      const response = await axios.post(
        `${process.env.NEXT_PUBLIC_BACKEND_URL}/api/blog`,
        credentials,
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        }
      );
      return response.data;
    } catch (error) {
      if (axios.isAxiosError(error) && error.response) {
        console.log(error);

        return rejectWithValue(error.response.data);
      } else {
        return rejectWithValue(error);
      }
    }
  }
);
