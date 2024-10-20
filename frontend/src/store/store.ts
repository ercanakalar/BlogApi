import { configureStore } from '@reduxjs/toolkit';
import authReducer from './slice/auth';
import blogReducer from './slice/blog';
import commentReducer from './slice/comment';

const store = configureStore({
  reducer: {
    auth: authReducer,
    blog: blogReducer,
    comment: commentReducer,
  },

  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware({
      serializableCheck: false,
    }),
});

export default store;
export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
