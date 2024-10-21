'use client';

import { useEffect } from 'react';
import { useSelector } from 'react-redux';
import { useRouter } from 'next/navigation';
import { AuthState } from '@/types/authState';

const Home = () => {
  const router = useRouter();
  const { isAuthenticated, user } = useSelector((state: { auth: AuthState }) => state.auth);

  useEffect(() => {
    if (!isAuthenticated) {
      router.push('/auth/signin');
    }
  }, [isAuthenticated, router]);

  return (
    <div>
      <h1>Welcome</h1>
    </div>
  );
};

export default Home;
