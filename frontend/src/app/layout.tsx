'use client';

import localFont from "next/font/local";
import "./globals.css";
import { Provider } from "react-redux";
import store from "@/store/store";
import heroPattern from "@/assets/hero-pattern.jpg";

const geistSans = localFont({
  src: "./fonts/GeistVF.woff",
  variable: "--font-geist-sans",
  weight: "100 900",
});
const geistMono = localFont({
  src: "./fonts/GeistMonoVF.woff",
  variable: "--font-geist-mono",
  weight: "100 900",
});

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <Provider store={store}>
      <html lang="en">
        <head>
          <title>{'Blog'}</title>
          <meta
            name="viewport"
            content="width=device-width, initial-scale=1, minimum-scale=1"
          />
        </head>
        <body
          className={`${geistSans.variable} ${geistMono.variable} antialiased bg-cover`}
          style={{ backgroundImage: `url(${heroPattern.src})` }}
        >
          {children}
        </body>
      </html>
    </Provider>
  );
}
