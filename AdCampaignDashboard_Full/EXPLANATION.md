# EXPLANATION

## 1. State Management Strategy
Optimistic UI updates give instant feedback to the user without waiting for the server response, improving perceived performance.
Challenge: If multiple updates happen quickly, stale state can overwrite new state. This requires careful rollback handling and possibly using functional setState or centralized state management like Redux.

## 2. API Security
API key in header is easy to implement but can be intercepted if sent over non-HTTPS, and anyone with the key can access the API.
In production, I would use OAuth 2.0 or JWT-based authentication with proper authorization checks, ensuring keys are short-lived and scoped.

## 3. Performance
For thousands of campaigns:
- Rendering Bottleneck: Large DOM updates → use virtualization libraries (e.g., react-window).
- Data Fetching Bottleneck: Large payloads → implement server-side pagination, filtering, and sorting.
