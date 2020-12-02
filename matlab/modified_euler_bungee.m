function [t, y, v, h] = modified_euler_bungee(T, n, g, C, K, L)
%modified_euler_bungee Modified Euler's method for the bungee jumping model
% [t, y, v, h] = euler_bungee(T, n, g, C, K, L) performs Euler's method on
% the bungee jumping model, taking n steps from t = 0 to t = T.
% The initial conditions are y(0) = 0 and v(0) = 0.
% Inputs:
%   g: Gravity
%   C: Drag coefficient
%   K: spring constant of the bungee cord
%   L: Length of the bungee cord
% 
% Outputs:
%   t: time
%   y: distance from starting position
%   v: velocity during jump
% subinterval width h.
% Calculate subinterval width h
h = T / n;
% Create time array t
t = 0:h:T;
% Initialise solution arrays y and v
y = zeros(1,n+1);
v = zeros(1,n+1);
% Perform iterations
f1 = @(t,y,v) v;
f2 = @(t,y,v) g - C*abs(v)*v - max(0, K*(y - L)); 
y(1) = 0;
v(1) = 0;
for j = 1:n
    k_y1 = h*f1(t,y(j),v(j));
    k_v1 = h*f2(t,y(j),v(j));
    k_y2 = h*f1(t + h,y(j)+ k_y1,v(j)+k_v1);
    k_v2 = h*f2(t + h,y(j)+ k_y1,v(j)+k_v1);
    
    y(j+1) = y(j) + 1/2 * (k_y1 + k_y2);
    v(j+1) = v(j) + 1/2 * (k_v1 + k_v2);
    
end