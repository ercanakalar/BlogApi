import { getBlogById } from '@/libs/blog/getBlogById';
import { getBlogs } from '@/libs/blog/getBlogs';
import { BlogPost, BlogState } from '@/types/blogState';
import { createSlice, PayloadAction } from '@reduxjs/toolkit';

const initialState: BlogState = {
  posts: [],
  post: null,
  isLoading: false,
  error: null,
};

export const blogSlice = createSlice({
  name: 'blog',
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(getBlogs.pending, (state) => {
        state.isLoading = true;
        state.error = null;
      })
      .addCase(
        getBlogs.fulfilled,
        (state, action: PayloadAction<BlogPost[]>) => {
          state.posts = action.payload;
          state.isLoading = false;
        }
      )
      .addCase(getBlogs.rejected, (state, action) => {
        state.isLoading = false;
        state.error = action.payload as string;
      });

    builder
      .addCase(getBlogById.pending, (state) => {
        state.isLoading = true;
        state.error = null;
      })
      .addCase(
        getBlogById.fulfilled,
        (state, action: PayloadAction<BlogPost>) => {
          state.post = action.payload;
          state.isLoading = false;
        }
      )
      .addCase(getBlogById.rejected, (state, action) => {
        state.isLoading = false;
        state.error = action.payload as string;
      });
  },
});

export default blogSlice.reducer;
