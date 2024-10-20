"use client"
import { useDispatch, useSelector } from 'react-redux';
import { useEffect } from 'react';
import axios from 'axios';

import { logout, setCredentials } from '../store/slice/auth';
import { AppDispatch } from '@/store/store';

import { AuthState } from '@/types/authState';
import { signIn } from '@/libs/auth/signIn';

const useAuth = () => {
    const dispatch: AppDispatch = useDispatch();
    const { user, token, isAuthenticated, isLoading, error } = useSelector((state: { auth: AuthState }) => state.auth);

    useEffect(() => {
        const storedToken = localStorage.getItem('authToken');
        if (storedToken) {
            dispatch(setCredentials({ user: null, token: storedToken }));
        }
    }, [dispatch]);

    const login = async (credentials: { email: string; password: string }) => {
        await dispatch(signIn(credentials)).unwrap() as { user: AuthState['user']; token: string };
    };

    const signout = async () => {
        try {
            await axios.post('/api/auth/signout');

            dispatch(logout());
        } catch (error) {
            console.error('Failed to sign out:', error);
        }
    };

    return {
        user,
        token,
        isAuthenticated,
        isLoading,
        error,
        login,
        signout
    };
};

export default useAuth;
