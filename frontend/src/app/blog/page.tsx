'use client';

import { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { useSelector, useDispatch } from 'react-redux';
import { AppDispatch } from '@/store/store';
import { getBlogs } from '@/libs/blog/getBlogs';
import heroPattern from '../../assets/hero-pattern.jpg';
import { BlogPost, BlogState } from '@/types/blogState';

const Blogs = () => {
  const router = useRouter();
  const dispatch = useDispatch<AppDispatch>();

  const { posts, isLoading, error } = useSelector(
    (state: { blog: BlogState }) => state.blog
  );

  useEffect(() => {
    dispatch(getBlogs());
  }, [dispatch]);

  const truncateContent = (content: string, wordLimit: number) => {
    const words = content.split(' ');
    if (words.length > wordLimit) {
      return words.slice(0, wordLimit).join(' ') + '...';
    }
    return content;
  };

  if (isLoading) {
    return <p>Loading...</p>;
  }

  return (
    <div
      className='h-full bg-cover'
      style={{ backgroundImage: `url(${heroPattern.src})` }}
    >
      <div className='flex flex-col justify-center items-center gap-20 text-black'>
        <nav className='bg-white w-full flex'>
          <></>
          <div className='flex justify-center w-full'>
            <p>Blog Articles</p>
          </div>
          <div>
            <button onClick={() => router.push('blog/create')} className='w-fit whitespace-nowrap bg-gray-500/70 py-1 px-2 rounded'>+Create Blog</button>
          </div>
        </nav>

        {isLoading && <p>Loading...</p>}
        {error && <p className='text-red-500'>{error}</p>}

        {!isLoading && posts.length > 0
          ? posts.map((post: BlogPost) => (
              <div key={post.id} className='w-1/2 mb-6'>
                <div className='relative w-full'>
                  <span className='absolute p-1 left-4 -top-7 rounded-t bg-gray-800/50 text-sm text-white'>
                    {new Date(post.createdAt).toLocaleDateString('tr-TR', {
                      weekday: 'long',
                      year: 'numeric',
                      month: 'long',
                      day: '2-digit',
                    })}
                  </span>
                </div>
                <div className='bg-white rounded-xl p-4'>
                  <h2 className='text-2xl font-semibold mb-2'>{post.title}</h2>
                  <p>
                    {truncateContent(post.content, 100)}{' '}
                    <button
                      onClick={() => router.push(`/blog/${post.id}`)}
                      className='mt-2 text-indigo-600 hover:underline'
                    >
                      Read more
                    </button>
                  </p>

                  <p className='mt-2 text-sm text-gray-600'>
                    Gönderen {post.user.userName} zaman:
                    {new Date(post.createdAt).toLocaleTimeString('tr-TR', {
                      hour: '2-digit',
                      minute: '2-digit',
                      second: '2-digit',
                      hour12: false,
                      timeZone: 'Europe/Istanbul',
                    })}
                    yorum: {post.comments.length}
                  </p>
                </div>
              </div>
            ))
          : !isLoading && <p>No blogs available</p>}
      </div>
    </div>
  );
};

export default Blogs;
