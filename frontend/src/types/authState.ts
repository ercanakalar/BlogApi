export type AuthState = {
  user: User;
  token: string | null;
  isAuthenticated: boolean;
  isLoading: boolean;
  error: unknown | null;
};

export type User = {
  id: number;
  userName: string;
  email: string;
};
