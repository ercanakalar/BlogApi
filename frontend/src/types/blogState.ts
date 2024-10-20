interface User {
  id: number;
  userName: string;
  email: string;
}
export interface BlogPost {
  id: number;
  title: string;
  content: string;
  createdAt: string;
  updatedAt: string;
  user: User;
  comments: Comment[];
}

export interface BlogByIdPost {
  id: number;
  content: string;
  createdAt: string;
  userId: number;
  comments: Comment[];
  user: {
    id: number;
    userName: string;
    email: string;
  };
}

export interface BlogState {
  posts: BlogPost[];
  post: BlogPost | null;
  isLoading: boolean;
  error: string | null;
}

export interface Comment {
  id: number;
  content: string;
  createdAt: string;
  updatedAt: string;
  user: User;
}
