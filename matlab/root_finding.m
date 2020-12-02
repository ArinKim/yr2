function [p,t] = bisection(y1,y2,t1,t2,ite)
%BISECTION Bisection method
% p = bisection(f, a, b, n) returns the most recently computed midpoint
% after applying n iterations of the bisection method for solving f(x) = 0,
% where f is an anonymous function for f(x), and [a,b] is the initial bracketing.
% Errors are raised if f is not given as an anonymous function and if [a,b]
% does not bracket the root.

H = 74;
D = 31;
if sign(y1 - (H - D)) == sign(y2 - (H - D))
    error('f(a) and f(b) must have opposite signs.')
end

n = size(ite);

for i = 1:n
    p = (y1 + y2) / 2;  
    t = (t1 + t2) / 2;
    % compute the midpoint value
    if sign(y1 - (H - D)) == sign(p - (H - D))
        y1 = p;  % complete the missing line
        t1 = t;
    else
        y2 = p;
        t2 = t;
    end
% complete the missing lineend
end