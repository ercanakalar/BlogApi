import { createAsyncThunk } from '@reduxjs/toolkit';
import axios from 'axios';

export const getCommentsByBlogId = createAsyncThunk(
  'blog/getCommentsByBlogId',
  async (id: string | number, { rejectWithValue }) => {
    try {
      const response = await axios.get(
        `${process.env.NEXT_PUBLIC_BACKEND_URL}/api/comment/${id}`
      );
      return response.data;
    } catch (error) {
      if (axios.isAxiosError(error) && error.response) {
        return rejectWithValue(error.response.data);
      } else {
        return rejectWithValue(error);
      }
    }
  }
);
