for i in range(10, -1, -1):
    if(i == 0):
        print(f"{i} green bottles hanging on the wall,\n" +
            f"{i} green bottles hanging on the wall,\n" +
            "And no one green bottle should accidentally fall,\n")
    else:
        print(f"{i} green bottles hanging on the wall,\n" +
                    f"{i} green bottles hanging on the wall,\n" +
                    "And if one green bottle should accidentally fall,\n" +
                    f"There'll be {i - 1} green bottles hanging on the wall.\n\n")
    