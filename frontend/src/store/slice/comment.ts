import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { getCommentsByBlogId } from '@/libs/comment/getComments';
import { Comment, CommentState } from '@/types/commentState';

const initialState: CommentState = {
  comments: [],
  comment: null,
  isLoading: false,
  error: null,
};

export const commentSlice = createSlice({
  name: 'comment',
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(getCommentsByBlogId.pending, (state) => {
        state.isLoading = true;
        state.error = null;
      })
      .addCase(
        getCommentsByBlogId.fulfilled,
        (state, action: PayloadAction<Comment[]>) => {
          state.comments = action.payload;
          state.isLoading = false;
        }
      )
      .addCase(getCommentsByBlogId.rejected, (state, action) => {
        state.isLoading = false;
        state.error = action.payload as string;
      });
  },
});

export default commentSlice.reducer;
