'use client';

import { getBlogById } from '@/libs/blog/getBlogById';
import { AppDispatch } from '@/store/store';
import { BlogState } from '@/types/blogState';
import { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { CommentById } from '@/types/commentState';


const BlogDetail = ({ params }: { params: { id: string } }) => {
    const dispatch = useDispatch<AppDispatch>();
    const { post, isLoading, error } = useSelector((state: { blog: BlogState }) => state.blog);

    useEffect(() => {
        dispatch(getBlogById(params.id));
    }, [dispatch, params.id]);

    if (isLoading) {
        return <p>Loading...</p>;
    }

    if (error) {
        return <p className="text-red-500">Error: {error}</p>;
    }

    if (!post) {
        return <p>No blog post found.</p>;
    }

    return (
        <div className="max-w-4xl mx-auto mt-8 bg-white p-8 rounded shadow">
            <h1 className="text-3xl font-semibold mb-4">{post.title}</h1>
            <p className="text-sm text-gray-500 mb-4">
                {new Date(post.createdAt).toLocaleDateString('tr-TR', {
                    weekday: 'long',
                    year: 'numeric',
                    month: 'long',
                    day: '2-digit',
                })}
            </p>
            <p className="mb-4">{post.content}</p>
            <div className="text-gray-700">
                <strong>Gönderen: </strong> {post.user ? post.user.userName : 'Unknown'}
            </div>

            <div className="mt-4">
                <h3 className="text-lg font-semibold">Comments</h3>
                {post.comments?.length > 0 ? (
                    <ul className="mt-2">
                        {post.comments.length > 0 && post.comments.map((comment: CommentById) => (
                            <li key={`${comment.content} + ${comment.id}`} className="border-t py-2">
                                <strong>{comment.user.userName}:</strong> {comment.content}
                            </li>
                        ))}
                    </ul>
                ) : (
                    <p>No comments yet.</p>
                )}
            </div>
        </div>
    );
};

export default BlogDetail;
