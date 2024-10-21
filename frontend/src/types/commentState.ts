export interface Comment {
  id: number;
  userId: string;
  blogId: string;
  content: string;
  createdAt: string;
  updatedAt: string;
  user: {
    id: number;
    userName: string;
    email: string;
  };
}

export interface CommentState {
  comments: Comment[];
  comment: Comment | null;
  isLoading: boolean;
  error: string | null;
}

export interface CommentById {
  id: number;
  content: string;
  createdAt: string;
  updatedAt: string;
  user: {
    id: number;
    userName: string;
    email: string;
  };
}
