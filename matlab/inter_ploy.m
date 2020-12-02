function py = inter_ploy(poly_times, poly_points,t)
%inter_poly Interpolating Polynomial finds a matching interpolating
%polynomial using the four values of t and y and returns the polynomial as
%a funtion

% Inputs:
%   t: series of four values of time
%   y: series of four values of distance

% Output:
%   p: the interpolating polynomial


n = length(poly_times);
py = zeros(size(t));
for i = 1:n
    L = ones(size(t));
    for j = [1:i-1 i+1:n]
        L = L .* ((t-poly_times(j)) / (poly_times(i) - poly_times(j)));
    end
    py = py + L * poly_points(i);
end


