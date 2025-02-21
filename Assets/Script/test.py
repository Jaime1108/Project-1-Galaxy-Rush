##Create a method that returns an array of numbers between 1 and 10000 that are divisible by 3, 7, or 21
def divisible_by():
    solution = []
    for i in range(1,10001, 1):
        if i % 7 ==0:
            solution.append(i)
        elif i % 3 == 0:
            solution.append(i)
    return solution
    
