import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { getCommentsByBlogId } from '@/libs/comment/getCommentsByBlogId';
import { Comment, CommentState } from '@/types/commentState';
import { sendComment } from '@/libs/comment/sendComment';
import { getComments } from '@/libs/comment/getComments';

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

    builder
      .addCase(sendComment.pending, (state) => {
        state.isLoading = true;
        state.error = null;
      })
      .addCase(
        sendComment.fulfilled,
        (state, action: PayloadAction<Comment>) => {
          console.log(action.payload);
          
          state.comments = [...state.comments, action.payload];
          state.isLoading = false;
        }
      )
      .addCase(sendComment.rejected, (state, action) => {
        state.isLoading = false;
        state.error = action.payload as string;
      });

    builder
      .addCase(getComments.pending, (state) => {
        state.isLoading = true;
        state.error = null;
      })
      .addCase(
        getComments.fulfilled,
        (state, action: PayloadAction<Comment[]>) => {
          state.comments = action.payload;
          state.isLoading = false;
        }
      )
      .addCase(getComments.rejected, (state, action) => {
        state.isLoading = false;
        state.error = action.payload as string;
      });
  },
});

export default commentSlice.reducer;
