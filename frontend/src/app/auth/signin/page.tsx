'use client';

import { useState } from 'react';
import { useRouter } from 'next/navigation';
import { AppDispatch } from '@/store/store';
import { useDispatch } from 'react-redux';
import { signIn } from '@/libs/auth/signIn';

const SignIn = () => {
    const router = useRouter();
    const dispatch = useDispatch<AppDispatch>();
    const [user, setUser] = useState<{
        email: string;
        password: string;
    }>({
        email: '',
        password: '',
    });
    const [error, setError] = useState<string | null>(null);
    const [isLoading, setIsLoading] = useState(false);

    const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        setIsLoading(true);
        try {
            const resultAction = await dispatch(signIn(user));
            
            if (signIn.fulfilled.match(resultAction)) {
                router.push('/blog');
            }
            if (signIn.rejected.match(resultAction)) {
                setError(resultAction.payload as string || 'An error occurred.');
            }
        } catch (err: unknown) {
            if (err instanceof Error) {
                setError(err.message);
            } else {
                setError('An unknown error occurred.');
            }
        } finally {
            setIsLoading(false);
        }
    };

    return (
        <div className="flex justify-center items-center min-h-screen bg-gray-100">
            <div className="w-full max-w-md p-8 space-y-4 bg-white rounded-lg shadow-md">
                <h1 className="text-2xl font-semibold text-center text-gray-600">Sign In</h1>
                <form onSubmit={handleSubmit} className="space-y-6 text-black">
                    <div>
                        <label htmlFor="email" className="block text-sm font-medium text-gray-700">
                            Email
                        </label>
                        <input
                            id="email"
                            type="email"
                            required
                            value={user.email}
                            onChange={(e) => setUser({ ...user, email: e.target.value })}
                            className="w-full px-3 py-2 mt-1 border border-gray-300 rounded-lg focus:outline-none focus:ring focus:ring-indigo-100"
                        />
                    </div>

                    <div>
                        <label htmlFor="password" className="block text-sm font-medium text-gray-700">
                            Password
                        </label>
                        <input
                            id="password"
                            type="password"
                            required
                            value={user.password}
                            onChange={(e) => setUser({ ...user, password: e.target.value })}
                            className="w-full px-3 py-2 mt-1 border border-gray-300 rounded-lg focus:outline-none focus:ring focus:ring-indigo-100"
                        />
                    </div>
                    {error && (
                        <div className="p-2 bg-red-100 border border-red-400 text-red-700 rounded">
                            {error}
                        </div>
                    )}

                    <button
                        type="submit"
                        className={`w-full py-2 px-4 font-semibold text-white bg-indigo-600 rounded-lg ${isLoading ? 'opacity-50 cursor-not-allowed' : ''}`}
                        disabled={isLoading}
                    >
                        {isLoading ? 'Signing In...' : 'Sign In'}
                    </button>
                </form>
                <p className="text-sm text-gray-600">
                    Already do not have an account?
                    <a href="/auth/signup" className="text-indigo-600 hover:text-indigo-500">
                        Sign Up
                    </a>
                </p>
            </div>
        </div>
    );
};

export default SignIn;
